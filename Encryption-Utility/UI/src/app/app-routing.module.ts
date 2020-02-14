import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EncryptionUtilityComponent } from './encryption-utility/encryption-utility.component';

const routes: Routes = [
  { path: 'encryptionUtility', component: EncryptionUtilityComponent },
  { path: '', redirectTo: 'encryptionUtility', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
