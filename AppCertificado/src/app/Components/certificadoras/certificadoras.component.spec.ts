import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificadorasComponent } from './certificadoras.component';

describe('CertificadorasComponent', () => {
  let component: CertificadorasComponent;
  let fixture: ComponentFixture<CertificadorasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CertificadorasComponent]
    });
    fixture = TestBed.createComponent(CertificadorasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
