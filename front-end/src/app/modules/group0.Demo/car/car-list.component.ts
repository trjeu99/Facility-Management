import {
    Component,
    Injector,
    ViewChild,
    ViewEncapsulation,
    AfterViewInit,
    OnInit,
} from "@angular/core";
import { LazyLoadEvent } from "primeng/components/common/lazyloadevent";
import { AppComponentBase } from "@shared/common/app-component-base";
import {
    CarDto,
    CarServiceProxy,
} from "@shared/service-proxies/service-proxies";
import { Table } from "primeng/components/table/table";
import { Paginator } from "primeng/primeng";

@Component({
    templateUrl: "./car-list.component.html",
    styleUrls: ["./car.component.less"],
    encapsulation: ViewEncapsulation.None,
})
export class CarListComponent extends AppComponentBase
    implements AfterViewInit {
    /**
     *
     */
    @ViewChild("dataTable") dataTable: Table;
    @ViewChild("paginator") paginator: Paginator;

    constructor(injector: Injector, private carService: CarServiceProxy) {
        super(injector);
        this.currentUserName = this.appSession.user.userName;
        // this.carService.getCurrentUserName().subscribe(response=>{
        //   this.currentUserName = response;
        // })
        console.log(this);
    }

    currentUserName: string;
    filterInput: CarDto = new CarDto();
    records: CarDto[] = [];

    currentId: number;
    // search() {
    //     this.carService.cAR_Search(this.filterInput).subscribe((response) => {
    //         this.records = response;
    //     });
    // }

    delete() {
        this.carService.cAR_Del(this.currentId).subscribe((response) => {
            if (response["Result"] == "-1") {
                this.notify.error(response["ErrorDesc"]);
            } else {
                this.notify.success("Xóa thành công");
                this.search();
            }
        });
    }

    search(): void {
        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();
        this.carService.cAR_Search(this.filterInput).subscribe((result) => {
            let no = 1;
            result.forEach((item) => {
                item["no"] = no++;
            });
            this.primengTableHelper.totalRecordsCount = result.length;
            this.primengTableHelper.records = result;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    ngAfterViewInit(): void {
        this.search();
    }
}
