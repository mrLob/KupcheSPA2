import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityTypesFormComponent } from './activity-types-form.component';

describe('ActivityTypesFormComponent', () => {
  let component: ActivityTypesFormComponent;
  let fixture: ComponentFixture<ActivityTypesFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActivityTypesFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivityTypesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
