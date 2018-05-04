import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UniversitiesComponent } from './universities/universities.component';

const routes: Routes = [
    { path: 'universities', component: UniversitiesComponent },
    { path: '**', redirectTo: '/universities' }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }