import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CertificadoAnuncio } from "./CertificadoAnuncio"

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }

@Injectable({
  providedIn: 'root'
})
export class CertificadoAnuncioService {
  apiUrl = 'http://localhost:5000/CertificadoAnuncio';
  constructor(private http: HttpClient) { }
}
