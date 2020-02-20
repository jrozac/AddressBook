import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PagingComponent } from './paging/paging.component';
import { LoaderComponent } from './loader/loader.component';
import { ModalWindowComponent } from './modal-window/modal-window.component';
import { ContactDataComponent } from './contact/contact-data.component';
import { ContactSearchComponent } from './contact/contact-search.component';
import { ContactGetComponent } from './contact/contact-get.component';
import { ContactEditComponent } from './contact/contact-edit.component';
import { ContactNewComponent } from './contact/contact-new.component';
import { ContactEditFormComponent } from './contact/contact-edit-form.component';
import { ContactDeleteComponent } from './contact/contact-delete.component';
import { AdminResetComponent } from './admin/admin-reset.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PagingComponent,
    LoaderComponent,
    ModalWindowComponent,
    ContactDataComponent,
    ContactSearchComponent,
    ContactGetComponent,
    ContactEditComponent,
    ContactNewComponent,
    ContactEditFormComponent,
    ContactDeleteComponent,
    AdminResetComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'contacts', component: ContactSearchComponent },
      { path: 'contacts/get/:id', component: ContactGetComponent },
      { path: 'contacts/edit/:id', component: ContactEditComponent },
      { path: 'contacts/delete/:id', component: ContactDeleteComponent },
      { path: 'contacts/new', component: ContactNewComponent },
      { path: 'admin/reset', component: AdminResetComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
