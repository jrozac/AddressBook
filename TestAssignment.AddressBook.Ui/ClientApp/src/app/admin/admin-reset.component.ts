import { Component, ViewChild, OnInit } from '@angular/core';
import { ItemActionBase } from '../generics/item-action-base';
import { Observable, of as _observableOf } from 'rxjs';
import { map } from 'rxjs/operators';
import { ContactsClient } from '../../api/api.phone.client';
import { ActivatedRoute } from '@angular/router';
import { ModalWindowComponent } from '../modal-window/modal-window.component';

@Component({
  selector: 'app-admin-reset',
  templateUrl: './admin-reset.component.html',
  providers: [ContactsClient]
})
export class AdminResetComponent extends ItemActionBase<boolean> implements OnInit {

  @ViewChild('modalconfirm', { static: false }) modalConfirm: ModalWindowComponent;

  /** Call API for save */
  public actionApi(): Observable<boolean> {
    return this.api.reset().pipe(map(() => true));
  }

  /**
   * Call API to get data
   * @param id
   */
  public loadApi(id: string): Observable<boolean> {
    return _observableOf<boolean>(true);
  }

  /** Confirm reset */
  public confirmReset(): void {
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
