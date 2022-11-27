import { Component } from "@angular/core";
import {ApexChart, ApexNonAxisChartSeries, NgApexchartsModule} from "ng-apexcharts";
import { OnInit} from "@angular/core";

@Component({
    selector: 'diagram',
    templateUrl: './diagram.component.html',
    styleUrls: ['./diagram.component.css']
})
export class DiagramComponent implements OnInit{
    
    public chartSeries: ApexNonAxisChartSeries = [40, 32, 28, 55];
    
    public chartDetails: ApexChart = {
        type: 'pie',
        toolbar: {
            show: true
        }
    };

    constructor() {
    }

    ngOnInit() {
    }
}