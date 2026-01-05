import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HedarpageComponent } from './hedarpage/hedarpage.component';
import { RoutpageComponent } from "./routpage/routpage.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HedarpageComponent, RoutpageComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ReceiptWeb';
}
