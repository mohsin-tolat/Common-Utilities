import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EncryptionUtilityComponent } from './encryption-utility.component';

describe('EncryptionUtilityComponent', () => {
  let component: EncryptionUtilityComponent;
  let fixture: ComponentFixture<EncryptionUtilityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EncryptionUtilityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EncryptionUtilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
