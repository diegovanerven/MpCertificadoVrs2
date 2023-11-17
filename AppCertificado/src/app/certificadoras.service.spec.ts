import { TestBed } from '@angular/core/testing';

import { CertificadorasService } from './certificadoras.service';

describe('CertificadorasService', () => {
  let service: CertificadorasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CertificadorasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
