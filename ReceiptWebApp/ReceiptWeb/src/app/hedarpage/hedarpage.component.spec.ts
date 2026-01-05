import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HedarpageComponent } from './hedarpage.component';

describe('HedarpageComponent', () => {
  let component: HedarpageComponent;
  let fixture: ComponentFixture<HedarpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HedarpageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HedarpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
