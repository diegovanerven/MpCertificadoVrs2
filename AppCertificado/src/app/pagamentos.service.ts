import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pagamento } from './Pagamento'; // Importe a classe Certificadora

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class PagamentosService {
  private apiUrl = 'http://localhost:5000/Pagamento/CadastroPagamento'; // Mantenha o caminho do backend

  constructor(private http: HttpClient) { }

  listar(): Observable<Pagamento[]> {
    return this.http.get<Pagamento[]>(`${this.apiUrl}/listar`);
  }

  buscar(id: string): Observable<Pagamento> {
    return this.http.get<Pagamento>(`${this.apiUrl}/buscar/${id}`);
  }

  cadastrar(certificadora: Pagamento): Observable<any> {
    return this.http.post<Pagamento>(`${this.apiUrl}/cadastrar`, certificadora, httpOptions);
  }

  atualizar(certificadora: Pagamento): Observable<any> {
    return this.http.put<Pagamento>(`${this.apiUrl}/atualizar`, certificadora, httpOptions);
  }

  excluir(id: string): Observable<any> {
    return this.http.delete<string>(`${this.apiUrl}/excluir/${id}`, httpOptions);
  }
}
