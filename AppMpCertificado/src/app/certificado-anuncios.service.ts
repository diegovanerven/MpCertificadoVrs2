import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CertificadoAnuncio } from './CertificadoAnuncio';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CertificadoAnunciosService {
  apiUrl = 'http://localhost:5000/CertificadoAnuncio';
  constructor(private http: HttpClient) { }
  listar(): Observable<CertificadoAnuncio[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<CertificadoAnuncio[]>(url);
  }

  buscar(IdCertificadoA: string): Observable<CertificadoAnuncio> {
    const url = `${this.apiUrl}/buscar/${IdCertificadoA}`;
    return this.http.get<CertificadoAnuncio>(url);
  }

  cadastrar(certificadoAnuncio: CertificadoAnuncio): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<CertificadoAnuncio>(url, certificadoAnuncio, httpOptions);
  }

  atualizar(certificadoAnuncio: CertificadoAnuncio): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<CertificadoAnuncio>(url, certificadoAnuncio, httpOptions);
  }

  excluir(IdCertificadoA: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${IdCertificadoA}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
