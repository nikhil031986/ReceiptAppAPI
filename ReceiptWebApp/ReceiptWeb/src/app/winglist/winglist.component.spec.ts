import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WinglistComponent } from './winglist.component';

describe('WinglistComponent', () => {
  let component: WinglistComponent;
  let fixture: ComponentFixture<WinglistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WinglistComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WinglistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
