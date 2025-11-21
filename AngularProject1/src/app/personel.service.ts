import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PersonelListeDTO, PersonelListeCO } from '../models/personel';

@Injectable({
  providedIn: 'root'
})
export class PersonelService {

  private apiUrl = 'https://localhost:7090/api/personelapi/liste';

  constructor(private http: HttpClient) { }

  getPersonelListe(kriter: PersonelListeCO): Observable<PersonelListeDTO[]> {
    return this.http.post<PersonelListeDTO[]>(this.apiUrl, kriter);
  }
}
