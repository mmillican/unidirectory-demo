import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { environment } from '../../environments/environment';
import { University } from './models/university';

@Injectable()
export class UniversityService {

  constructor(
    private _http: Http
  ) { }

  search(name: string): Observable<Array<University>> {
    let url = environment.apiBaseUrl + 'universities';

    const params = new URLSearchParams();
    params.append('name', name);

    url += '?' + params.toString();

    return this._http.get(url)
      .map((response: Response) => response.json() as University[]);
  }
}
