import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Filme } from '../models/filme';

@Injectable({
  providedIn: 'root'
})

export class FilmeService {

  baseUrl = environment.UrlAPI;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Filme[]> {
    return this.http.get<Filme[]>(`${this.baseUrl}/api/filme`);
  }

  create(filme: Filme) {
    return this.http.post(`${this.baseUrl}/api/filme`, filme);
  }

  edit(filme: Filme) {
    return this.http.put(`${this.baseUrl}/api/filme/${filme.id}`, filme);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/api/filme/${id}`);
  }
}
