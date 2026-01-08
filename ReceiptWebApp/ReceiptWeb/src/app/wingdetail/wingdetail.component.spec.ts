import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WingdetailComponent } from './wingdetail.component';

describe('WingdetailComponent', () => {
  let component: WingdetailComponent;
  let fixture: ComponentFixture<WingdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WingdetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WingdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
