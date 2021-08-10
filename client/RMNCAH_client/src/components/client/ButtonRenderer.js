import React from "react";
import {Button} from '@material-ui/core';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import * as ACTION_TYPES from '../../actions/actions';

function ButtonRenderer(params) {
//   const refresh = (param) => {
//     return true;
//   };
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const onClick = () => {
      
    if (params.onClick instanceof Function) {
      // const retParams = {
      //   // event: e,
      //   rowData: params.node.data,
      // };
    //   params.onClick(retParams);
      dispatch({
        type: ACTION_TYPES.SET_CLIENT_DETAILS,
        payload: params.node.data
      });

      // console.log(params.node.data);
      navigate('/app/clientClinicalDetails');
    }
  };
  return (
    // <button className="button btn-primary" onClick={onClick}>
    //   Select
    // </button>
    <Button
    color="primary"
    type="submit"
    variant="outlined"
    size="small"
    onClick={onClick}
  >
    Select
  </Button>
  );
}

export { ButtonRenderer };