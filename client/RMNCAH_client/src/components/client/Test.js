import React, { Component } from "react";
import { render } from "react-dom";
import { AgGridColumn, AgGridReact } from "ag-grid-react";

// import "ag-grid-enterprise";
import "ag-grid-community/dist/styles/ag-grid.css";
import "ag-grid-community/dist/styles/ag-theme-alpine.css";

class Test extends Component {
  constructor(props) {
    super(props);

    this.state = {
      columnDefs: [
        {
          field: "athlete",
          minWidth: 150
        }
      ],
      defaultColDef: {
        flex: 1,
        minWidth: 100
      },
      rowData: [],
      backupRowData: []
    };
  }

  getRowNodeId = data => {
    return data.id;
  };

  addRowData = () => {
    let newRowData = this.state.rowData.slice();
    let newId =
      this.state.rowData.length === 0
        ? 0
        : this.state.rowData[this.state.rowData.length - 1].id + 1;
    let newRow = { athlete: "new athlete", id: newId };
    newRowData.push(newRow);
    this.setState({ rowData: newRowData });
  };

  removeRowData = () => {
    let selectedRow = this.gridApi.getSelectedRows()[0];
    let newRowData = this.state.rowData.filter(row => {
      return row !== selectedRow;
    });
    this.setState({ rowData: newRowData });
  };

  updateEvenRowData = () => {
    let newRowData = this.state.rowData.map((row, index) => {
      if (index % 2 === 0) {
        return { ...row, athlete: "Even Row" };
      }
      return row;
    });
    this.setState({ rowData: newRowData });
  };

  updateOddRowData = () => {
    let newRowData = this.state.rowData.map((row, index) => {
      if (index % 2 !== 0) {
        return { ...row, athlete: "Odd Row" };
      }
      return row;
    });
    this.setState({ rowData: newRowData });
  };

  resetRowData = () => {
    this.setState({ rowData: this.state.backupRowData });
  };

  onGridReady = params => {
    this.gridApi = params.api;
    this.gridColumnApi = params.columnApi;

    const httpRequest = new XMLHttpRequest();
    const updateData = data => {
      data.length = 10;
      data = data.map((row, index) => {
        return { ...row, id: index + 1 };
      });
      this.setState({ rowData: data, backupRowData: data });
    };

    httpRequest.open(
      "GET",
      "https://raw.githubusercontent.com/ag-grid/ag-grid/master/grid-packages/ag-grid-docs/src/olympicWinnersSmall.json"
    );
    httpRequest.send();
    httpRequest.onreadystatechange = () => {
      if (httpRequest.readyState === 4 && httpRequest.status === 200) {
        updateData(JSON.parse(httpRequest.responseText));
      }
    };
  };

  render() {
    return (
      <div style={{ width: "600px", height: "600px" }}>
        <button onClick={() => this.addRowData()}>Append row</button>
        <button onClick={() => this.removeRowData()}>
          Delete selected row
        </button>
        <button onClick={() => this.updateOddRowData()}>Update odd rows</button>
        <button onClick={() => this.updateEvenRowData()}>
          Update even rows
        </button>
        <button onClick={() => this.resetRowData()}>Reset rows</button>
        <div
          id="myGrid"
          style={{
            height: "100%",
            width: "100%"
          }}
          className="ag-theme-alpine"
        >
          <AgGridReact
            getRowNodeId={this.getRowNodeId}
            columnDefs={this.state.columnDefs}
            defaultColDef={this.state.defaultColDef}
            rowSelection={"single"}
            onGridReady={this.onGridReady}
            immutableData={true}
            rowData={this.state.rowData}
          />
        </div>
      </div>
    );
  }
}

export default Test;