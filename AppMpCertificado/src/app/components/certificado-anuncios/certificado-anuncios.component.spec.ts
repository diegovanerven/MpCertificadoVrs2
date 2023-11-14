import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificadoAnunciosComponent } from './certificado-anuncios.component';

describe('CertificadoAnunciosComponent', () => {
  let component: CertificadoAnunciosComponent;
  let fixture: ComponentFixture<CertificadoAnunciosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CertificadoAnunciosComponent]
    });
    fixture = TestBed.createComponent(CertificadoAnunciosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
