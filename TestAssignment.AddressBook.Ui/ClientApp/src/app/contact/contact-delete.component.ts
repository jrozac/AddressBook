import { Component, OnInit, ViewChild } from '@angular/core';
import { ContactsClient, ContactDto } from '../../api/api.phone.client';
import { ActivatedRoute } from '@angular/router';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { ItemActionBase } from './../generics/item-action-base';
import { map } from 'rxjs/operators';
import { ModalWindowComponent } from '../modal-window/modal-window.component';

@Component({
  selector: 'app-contact-delete',
  templateUrl: './contact-delete.component.html',
  providers: [ContactsClient]
})

export class ContactDeleteComponent extends ItemActionBase<ContactDto> implements OnInit {

  @ViewChild('modalconfirm', { static: false }) modalConfirm: ModalWindowComponent;

  /** Call API for save */
  public actionApi(): Observable<ContactDto> {
    let obs = this.api.delete(this.item.id);
    return obs.pipe<ContactDto>(map(() => this.item ));
  }

  /**
   * Call API to get data
   * @param id
   */
  public loadApi(id: string): Observable<ContactDto> {
    return this.api.get(id);
  }

  /** Confirm delete */
  public confirmDelete(): void {
    this.modalConfirm.open();
  }

  /**
   * Constructor with route and api client injection
   * @param api
   * @param route
   */
  constructor(api: ContactsClient, route: ActivatedRoute) {
    super(api, route);
  }

}

