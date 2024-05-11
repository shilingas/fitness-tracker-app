import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseCreationFormComponent } from './exercise-creation-form.component';

describe('ExerciseCreationFormComponent', () => {
  let component: ExerciseCreationFormComponent;
  let fixture: ComponentFixture<ExerciseCreationFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExerciseCreationFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExerciseCreationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
