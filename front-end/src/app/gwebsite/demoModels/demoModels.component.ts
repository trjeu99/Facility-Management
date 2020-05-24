import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Component, Injector, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Table } from 'primeng/components/table/table';
import { CreateOrEditDemoModelModalComponent } from './create-or-edit-demoModel-modal.component';
import { DemoModelServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/primeng';
import * as moment from 'moment';

@Component({
    templateUrl: './demoModels.component.html',
    animations: [appModuleAnimation()]
})
export class DemoModelsComponent extends AppComponentBase implements AfterViewInit, OnInit {

    @ViewChild('createOrEditDemoModelModal') createOrEditDemoModelModal: CreateOrEditDemoModelModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;


    //Filters
    valueFilter: number;
    dateFilter: moment.Moment;

    constructor(
        injector: Injector,
        private _demoModelService: DemoModelServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit(): void {
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    init(): void {
        //get params từ url để thực hiện filter

    }

    getDemoModels(event?: LazyLoadEvent): void {
        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        this._demoModelService.getDemoModelsByFilter(
            this.valueFilter,
            this.dateFilter,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    createDemoModel(): void {
        this.createOrEditDemoModelModal.show();
    }

    deleteDemoModel(id: number): void {
        let self = this;
        self.message.confirm(
            self.l('DemoModelDeleteWarningMessage', id),
            this.l('AreYouSure'),
            isConfirmed => {
                if (isConfirmed) {
                    this._demoModelService.deleteDemoModel(id).subscribe(() => {
                        this.getDemoModels();
                        abp.notify.success(this.l('SuccessfullyDeleted'));
                    });
                }
            }
        );
    }
}
