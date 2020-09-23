import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FilmesComponent } from './filmes/filmes.component';

const routes: Routes = [
  { path: '',  redirectTo: 'dashborad', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'filmes', component: FilmesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
