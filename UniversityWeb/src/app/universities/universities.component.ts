import { Component, OnInit } from '@angular/core';
import { UniversityService } from '../shared/university.service';
import { University } from '../shared/models/university';

@Component({
  selector: 'app-universities',
  templateUrl: './universities.component.html',
  styleUrls: ['./universities.component.css'],
  providers: [ UniversityService ]
})
export class UniversitiesComponent implements OnInit {
  searchName = '';

  universities: Array<University> = new Array<University>();
  get hasResults(): boolean {
    return this.universities && this.universities.length > 0;
  }

  constructor(
    private _universityService: UniversityService
  ) { }

  ngOnInit() {
  }

  search(): void {
    this._universityService.search(this.searchName).subscribe(result => {
      this.universities = result;
    });
  }
}
