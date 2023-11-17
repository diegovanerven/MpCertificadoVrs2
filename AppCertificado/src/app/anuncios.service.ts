import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Anuncio } from './Anuncio';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class AnunciosService {
  private apiUrl = 'http://localhost:5000/MpCertificadoAnuncio/CertificadoAnuncio';

  constructor(private http: HttpClient) { }

  listar(): Observable<Anuncio[]> {
    return this.http.get<Anuncio[]>(`${this.apiUrl}/listar`);
  }

  buscar(id: string): Observable<Anuncio> {
    return this.http.get<Anuncio>(`${this.apiUrl}/buscar/${id}`);
  }

  cadastrar(anuncio: Anuncio): Observable<any> {
    return this.http.post<Anuncio>(`${this.apiUrl}/cadastrar`, anuncio, httpOptions);
  }

  atualizar(anuncio: Anuncio): Observable<any> {
    return this.http.put<Anuncio>(`${this.apiUrl}/atualizar`, anuncio, httpOptions);
  }

  excluir(id: string): Observable<any> {
    return this.http.delete<string>(`${this.apiUrl}/excluir/${id}`, httpOptions);
  }
}
