import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarProposalComponent } from './car-proposal.component';

describe('CarProposalComponent', () => {
  let component: CarProposalComponent;
  let fixture: ComponentFixture<CarProposalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarProposalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarProposalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
