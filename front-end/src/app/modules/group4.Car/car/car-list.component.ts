import {
    Component,
    ViewEncapsulation,
    AfterViewInit,
    Injector,
} from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import {
    CarDto,
    CarServiceProxy,
} from "@shared/service-proxies/service-proxies";

@Component({
    templateUrl: "./car-list.component.html",
    encapsulation: ViewEncapsulation.None,
    styleUrls: ['./car.component.less'],
    animations: [appModuleAnimation()],
})
export class CarListComponent extends AppComponentBase
    implements AfterViewInit {
    /**
     *
     */
    constructor(injector: Injector, private carService: CarServiceProxy) {
        super(injector);
    }

    filterInput: CarDto = new CarDto();
    records: CarDto[] = [];

    search() {
        this.carService.cAR_Search(this.filterInput).subscribe((response) => {
            this.records = response;
        });
    }

    title = "Bat dau chuong trinh angular";

    ngAfterViewInit(): void {}
}
