import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor(private httpClient : HttpClient) { }

  apiUrl: string = 'https://localhost:44306/api/Candidate';

  headers = new HttpHeaders().set('Content-Type', 'application/json');

  //Create Candidate
  create(data:any): Observable<any> {
    return this.httpClient.post(this.apiUrl, data).pipe(
      catchError(this.handleError)
    ); 
  }

  //Get all Candidates
  list(): Observable<any> {
  return this.httpClient.get(this.apiUrl).pipe(
    catchError(this.handleError)
  ); 
  }

  //Get particular item
  getItem(id:any): Observable<any> {
    return this.httpClient.get(`${this.apiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }
  
  //Handle API errors
  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
  };

}
