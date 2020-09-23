import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Genero } from '../models/genero';

@Injectable({
  providedIn: 'root'
})

export class GeneroService {

  baseUrl = environment.UrlAPI;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Genero[]> {
    return this.http.get<Genero[]>(`${this.baseUrl}/api/genero`);
  }

}
