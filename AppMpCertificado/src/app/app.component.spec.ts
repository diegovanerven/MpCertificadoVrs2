import { expect } from 'chai';

describe('AppComponent', () => {
  it('should create the app', () => {
    // Teste se a instância do componente é criada
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).to.exist; // Use a função "to.exist" para verificar se está definido
  });

  it(`should have as title 'AppMpCertificado'`, () => {
    // Teste se o título do aplicativo está definido corretamente
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).to.equal('AppMpCertificado'); // Use a função "to.equal" para verificar a igualdade
  });

  it('should render title', () => {
    // Teste se o título é renderizado corretamente no HTML
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.content span')?.textContent).to.contain('AppMpCertificado app is running'); // Use "to.contain" para verificar a substring
  });
});
