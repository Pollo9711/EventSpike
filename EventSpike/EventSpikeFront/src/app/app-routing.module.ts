import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './core/layout/layout.component';

const routes: Routes = [
  {path: '', component: LayoutComponent, children: [
    { path: '', redirectTo: 'login', pathMatch: 'full'},
    {
      path: '',
      loadChildren: () => import('./features/home/home.module').then(m => m.HomeModule)
    },
    {
      path: 'login',
      loadChildren: () => import('./features/login/login.module').then(m => m.LoginModule)
    }
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
