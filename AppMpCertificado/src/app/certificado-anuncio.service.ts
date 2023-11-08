import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CertificadoAnuncio } from "./CertificadoAnuncio";

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

@Injectable({
  providedIn: 'root'
})
export class CertificadoAnuncioService {
  apiUrl = 'http://localhost:5000/CertificadoAnuncio';

  constructor(private http: HttpClient) { }

  listar(): Observable<CertificadoAnuncio[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<CertificadoAnuncio[]>(url);
  }

  buscar(id: number): Observable<CertificadoAnuncio> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<CertificadoAnuncio>(url);
  }

  cadastrar(certificadoAnuncio: CertificadoAnuncio): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<CertificadoAnuncio>(url, certificadoAnuncio, httpOptions);
  }

  alterar(certificadoAnuncio: CertificadoAnuncio): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<CertificadoAnuncio>(url, certificadoAnuncio, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete(url, httpOptions);
  }
}
