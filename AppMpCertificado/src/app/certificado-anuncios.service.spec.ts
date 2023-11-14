import { TestBed } from '@angular/core/testing';

import { CertificadoAnunciosService } from './certificado-anuncios.service';

describe('CertificadoAnunciosService', () => {
  let service: CertificadoAnunciosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CertificadoAnunciosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
