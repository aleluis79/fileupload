import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  constructor(private http: HttpClient) { }

  subirArchivo(formData: FormData): Observable<string> {
    return this.http.post("http://localhost:5207/File/upload", formData, {responseType: 'text'});
  }
}
