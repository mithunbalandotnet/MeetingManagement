import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendeeReportComponent } from './attendee-report.component';

describe('AttendeeReportComponent', () => {
  let component: AttendeeReportComponent;
  let fixture: ComponentFixture<AttendeeReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttendeeReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendeeReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
