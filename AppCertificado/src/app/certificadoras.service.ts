import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Certificadora } from './Certificadora'; // Ajuste o caminho conforme necessário

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CertificadorasService {
  private apiUrl = 'http://localhost:5000/Certificadora/AcCertificadora';

  constructor(private http: HttpClient) { }

  listar(): Observable<Certificadora[]> {
    return this.http.get<Certificadora[]>(`${this.apiUrl}/listar`);
  }

  buscar(id: string): Observable<Certificadora> {
    return this.http.get<Certificadora>(`${this.apiUrl}/buscar/${id}`);
  }

  cadastrar(certificadora: Certificadora): Observable<any> {
    return this.http.post<Certificadora>(`${this.apiUrl}/cadastrar`, certificadora, httpOptions);
  }

  atualizar(certificadora: Certificadora): Observable<any> {
    return this.http.put<Certificadora>(`${this.apiUrl}/atualizar`, certificadora, httpOptions);
  }

  excluir(id: string): Observable<any> {
    return this.http.delete<string>(`${this.apiUrl}/excluir/${id}`, httpOptions);
  }
}
