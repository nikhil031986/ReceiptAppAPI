import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoutpageComponent } from './routpage.component';

describe('RoutpageComponent', () => {
  let component: RoutpageComponent;
  let fixture: ComponentFixture<RoutpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RoutpageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RoutpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
