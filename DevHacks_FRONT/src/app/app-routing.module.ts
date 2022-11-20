import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HistoryComponent } from './history/history.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { RecoverPasswordComponent } from './recover-password/recover-password.component';
import { RegisterComponent } from './register/register.component';
import { RewardsComponent } from './rewards/rewards.component';
import { StartComponent } from './start/start.component';

const routes: Routes = [
  { path: '', redirectTo: 'start', pathMatch: 'full' },
  { path: 'history/:id', component: HistoryComponent },
  { path: 'login', component: LoginComponent },
  { path: 'recover', component: RecoverPasswordComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'rewards/:id', component: RewardsComponent },
  { path: 'start', component: StartComponent },
  { path: 'home/:id', component: MainComponent },
  { path: '**', component: StartComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
