import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { expect } from 'chai';
import CertificadoAnuncio from './CertificadoAnuncio';

describe('AppComponent', () => {
  let fixture: ComponentFixture<CertificadoAnuncio>;
  let app: CertificadoAnuncio;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CertificadoAnuncio],
    });
    fixture = TestBed.createComponent(CertificadoAnuncio);
    app = fixture.componentInstance;
  });

  it('should create the app', () => {
    expect(app).to.exist;
  });

  it(`should have as title 'AppMpCertificado'`, () => {
    expect(app.title).to.equal('AppMpCertificado');
  });

  it('should render title', () => {
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.content span')?.textContent).to.contain('AppMpCertificado app is running');
  });
});
