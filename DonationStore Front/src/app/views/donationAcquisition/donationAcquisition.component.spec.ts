/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DonationAcquisitionComponent } from './donationAcquisition.component';

describe('DonationAcquisitionComponent', () => {
  let component: DonationAcquisitionComponent;
  let fixture: ComponentFixture<DonationAcquisitionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DonationAcquisitionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DonationAcquisitionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
