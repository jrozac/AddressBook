import { Component, Input, Output, EventEmitter } from '@angular/core';
import { PagingDto } from '../../api/api.phone.client';

@Component({
  selector: 'app-paging',
  templateUrl: './paging.component.html',
})
export class PagingComponent {

  @Input()
  public paging: PagingDto;

  @Output()
  public pageSelectCallback = new EventEmitter();

  public loadNext(): void {
    if (this.nextPage() > 0) {
      this.pageSelectCallback.emit(this.currentPage() * this.paging.pageRecords);
    }
  }

  public loadPrev(): void {
    if (this.prevPage() > 0) {
      this.pageSelectCallback.emit((this.prevPage() - 1) * this.paging.pageRecords);
    }
  } 

  public prevPage(): number {
    return this.currentPage() > 1 ? this.currentPage() - 1 : 0;
  }

  public currentPage(): number {
    let cur = Math.ceil((this.paging.offset + 1) / this.paging.pageRecords);
    return cur;
  }

  public allPages(): number {
    let all = Math.ceil(this.paging.allRecords / this.paging.pageRecords);
    return all;
  }

  public nextPage(): number {
    return this.currentPage() < this.allPages() ? this.currentPage()+1 : 0;
  }

}
