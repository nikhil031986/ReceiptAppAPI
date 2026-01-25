import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';

export interface GridColumn {
  field: string;   // Property name in the data
  header: string;  // Column header text
  hideColumn?: boolean; // Optional flag to hide the column
  isBoolean?: boolean; // Optional flag to indicate boolean type
}

@Component({
  selector: 'app-grid-view',
  imports: [NgFor, NgIf],
  templateUrl: './grid-view.component.html',
  styleUrls: ['./grid-view.component.css'],
  standalone: true
})
export class GridViewComponent {
  @Input() columns: GridColumn[] = [];
  @Input() data: any[] = [];
  @Output() editRecord = new EventEmitter<any>();
  @Output() deleteRecord = new EventEmitter<any>();
  
  getPropertyValues<T, K extends keyof T>(arr: T[], key: K): T[K][] {
    if (!Array.isArray(arr) || !key) {
      return [];
    }
    return arr.map(item => item[key]);
  }

  getColumns(): string[] {
    if (!this.columns || this.columns.length === 0) return [];
    return this.columns.map(col => col.header).filter(h => !h.toLowerCase().includes('id'));
  }

  onEditRecord(row: any) {
    this.editRecord.emit(row);
  }

  onDeleteRecord(row: any) {
    this.deleteRecord.emit(row);
  }
}
