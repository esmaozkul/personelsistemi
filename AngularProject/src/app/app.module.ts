import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; // ngModel için gerekli

import { AppComponent } from './app.component';
import { PersonelListComponent } from './components/personel-list/personel-list.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonelListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
