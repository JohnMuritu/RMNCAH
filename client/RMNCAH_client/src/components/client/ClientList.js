import React, {Component} from 'react';
import axios from 'axios';
import { connect } from 'react-redux';
import { AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-balham.css'
import * as ACTION_TYPES from '../../actions/actions';
import { ButtonRenderer } from './ButtonRenderer';

class ClientList extends Component {
	constructor(props) {
		super(props);

		this.state = {
			columnDefs: [
				{headerName: "Client Id", field: "clientId", sortable: true, filter: true, hide: true},
				{headerName: "Client Names", field: "fullNames", sortable: true, filter: true},
				// {headerName: "DOB", field: "dob", sortable: true, filter: true},

        {
          headerName: 'DOB',
          field: 'dob',
          valueFormatter: this.dateFormatter,
        },

        {headerName: "Village", field: "village", sortable: true, filter: true},
        {headerName: "Phone Number", field: "phoneNumber", sortable: true, filter: true},
        {headerName: "Alternative PhoneNumber", field: "alternativePhoneNumber", sortable: true, filter: true},
        {headerName: "HF Linked", field: "hfLinked", sortable: true, filter: true},
        {headerName: "Other HF Attended", field: "otherHFAttended", sortable: true, filter: true},
        {
          headerName: '',
          cellRenderer: 'buttonRenderer',
          cellRendererParams: {
            onClick: this.onBtnClick.bind(this),
          }
        },
			],
      frameworkComponents: {
        buttonRenderer: ButtonRenderer,
      }
      
      //rowData: null,
		}
	}

  onBtnClick(e) {
    // this.rowDataClicked = e.rowData;
    // this.props.onSelectedRowChange(e.rowData);
  }

  dateFormatter = (params) => {
    var dateAsString = params.data.dob;
    var dateParts = dateAsString.split('T');
    return `${dateParts[0]}`; // - ${dateParts[1]} - ${dateParts[2]}`;
  }

  getClientList = () => {
    axios.get('/api/client/clientdetails')
      .then((response) => {    
        // this.setState({
        //   rowData: response.data
        // });
        this.props.getClientList(response.data);
      })
      .catch((error) => {
        console.log(`error : ${error}`);
      });
  }

  componentDidMount(){
    this.getClientList();
  }

  onButtonClick = () => {
    const selectedNode = this.gridApi.getSelectedNodes();
    const selectedRow = selectedNode.map(node => node.data);
    console.log(selectedRow);
  }

  onSelectionChanged = () => {
    var selectedRow = this.gridApi.getSelectedRows();
    this.props.onSelectedRowChange(selectedRow[0]);
  };

  sizeToFit = () => {
    this.gridApi.sizeColumnsToFit();
  };
	
  render() {
    return(
      <div
        className="ag-theme-balham"
        style={{
          // width: '100%',
          height: 400
        }}
      >
        <AgGridReact
          columnDefs={this.state.columnDefs}
          // rowData={this.state.rowData}
          rowData={this.props.client_list}
          rowSelection='single'
          onGridReady={params => this.gridApi = params.api}
          onSelectionChanged={this.onSelectionChanged.bind(this)}
          frameworkComponents={this.state.frameworkComponents}
        />

      </div>
    )
  }
}

const mapStateToProps = state => {
  return {
      // update_client_list: state.main_reducer.update_client_list,
      client_list: state.main_reducer.client_list
  };
};

const mapDispatchToProps = (dispatch) => {
  return {

      onSelectedRowChange: (value) => {
          dispatch({
              type: ACTION_TYPES.SET_CLIENT_DETAILS,
              payload: value
          });
        
          dispatch({
            type: ACTION_TYPES.UPDATE_CLIENT_DETAILS,
            payload: 1
          });
          
          
      },

      // SetUpdateClientListToZero: () => {
      //   dispatch({
      //     type: ACTION_TYPES.UPDATE_CLIENT_LIST,
      //     payload: 0
      //   });
      // },

      getClientList: (data) => {
        dispatch({
          type: ACTION_TYPES.CLIENT_LIST,
          payload: data
        });
      }

  };
}

export default connect(mapStateToProps, mapDispatchToProps)(ClientList);
