import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../models/constan';
import { Subject } from '../models/subject';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  url: string = Constants.BASE_URL + 'subjects/';
  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<Subject[]> {
    return this.httpClient.get<Subject[]>(this.url);
  }

  get(id: number): Observable<Subject> {
    return this.httpClient.get<Subject>(this.url + id);
  }

  add(form: any) {
    this.httpClient.post(this.url, form).subscribe({
      next: (data) => {
      },
      error: (error) => {
      },
    });
  }

  edit(form: any) {
    this.httpClient.put(this.url, form).subscribe({
      next: (data) => {
      },
      error: (error) => {
      },
    });
  }

  remove(id: number) {
    this.httpClient.delete(this.url + id).subscribe({
      next: (data) => {
      },
      error: (error) => {
      },
    });
  }
}
