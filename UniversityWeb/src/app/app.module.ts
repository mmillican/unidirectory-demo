import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UniversitiesComponent } from './universities/universities.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpModule } from '@angular/http';


@NgModule({
  declarations: [
    AppComponent,
    UniversitiesComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
