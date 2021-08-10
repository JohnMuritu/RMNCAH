import { useState, useEffect } from 'react';
import {
  Box,
  Button,
  Card,
  CardContent,
  CardHeader,
  Divider,
  Grid,
  TextField
} from '@material-ui/core';
import axios from 'axios';
import { useSelector, useDispatch } from 'react-redux';
import { NotificationManager } from 'react-notifications';
import { v4 as uuidv4 } from 'uuid';
import 'date-fns';
import DateFnsUtils from '@date-io/date-fns';
import { MuiPickersUtilsProvider, KeyboardDatePicker } from '@material-ui/pickers';
import moment from 'moment';
import * as ACTION_TYPES from '../../actions/actions';

const states = [
  {
    value: 'alabama',
    label: 'Alabama'
  },
  {
    value: 'new-york',
    label: 'New York'
  },
  {
    value: 'san-francisco',
    label: 'San Francisco'
  }
];

const ClientDetails = (props) => {

  const dispatch = useDispatch();

  const clientDetailsFetched = useSelector(state => state.main_reducer.clientDetails);
  const update_client_details = useSelector(state => state.main_reducer.update_client_details);

  const [values, setValues] = useState(clientDetailsFetched);

  const handleChange = (event) => {
    if(update_client_details === 1){
      dispatch({
        type: ACTION_TYPES.UPDATE_CLIENT_DETAILS,
        payload: 0
      });
    } 

    setValues({
      ...values,
      [event.target.name]: event.target.value
    });
  };

  const handleDOB = (event) => {
    if(update_client_details === 1){
      dispatch({
        type: ACTION_TYPES.UPDATE_CLIENT_DETAILS,
        payload: 0
      });
    } 
    //console.log('DOB - ' + new Date(moment(event).format('MM/DD/YYYY 03:00')));
    setValues({
      ...values,
      dob: new Date(moment(event).format('MM/DD/YYYY 03:00'))
    });

    console.log('values - ' + JSON.stringify(values));
  };

  const handleSave = () => {

    if(values.clientId === ""){
      values.clientId = uuidv4();
      axios.post('/api/client/addclientdetails', values)
      .then((response) => {
        NotificationManager.success('Saved Successfully!', '', 2000);
      })
      .catch((error) => {
        console.log(`error : ${error}`);
        NotificationManager.error('Error!', '', 10000);
      });
    }
    else{
      axios.post('/api/client/updateclientdetails', values)
      .then((response) => {
        NotificationManager.success('Updated Successfully!', '', 2000);
      })
      .catch((error) => {
        console.log(`error : ${error}`);
        NotificationManager.error('Error!', '', 10000);
      });
    }
    
    dispatch({
      type: ACTION_TYPES.SET_CLIENT_DETAILS,
      payload: values
    });

    axios.get('/api/client/clientdetails')
      .then((response) => {    
        dispatch({
          type: ACTION_TYPES.CLIENT_LIST,
          payload: response.data
        });
      })
      .catch((error) => {
        console.log(`error : ${error}`);
      });   

  };

  const resetClientDetails = () => {
    dispatch({
      type: ACTION_TYPES.UPDATE_CLIENT_DETAILS,
      payload: 0
    });

    setValues({
      clientId: '',
      fullNames: '',
      dob: new Date(),
      village: '',
      phoneNumber: '',
      alternativePhoneNumber: '',
      hfLinked: '',
      otherHFAttended: ''
    });
    
  };

  useEffect(() => {
    if(update_client_details === 1){
      setValues(clientDetailsFetched);
    }
    
  });

  return (
    <form
      onSubmit={handleSave}
      autoComplete="off"
    >
      <Card>
        <CardHeader
          title="Client Details"
        />
        <Divider />
        <CardContent>
          <Grid
            container
            spacing={3}
          >
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField            
                fullWidth
                label="Full names"
                name="fullNames"
                onChange={handleChange}
                // onBlur={handleBlur}
                required
                value={values.fullNames}
                variant="outlined"
                // helperText={touched.fullNames && errors.fullNames}
                // error={Boolean(touched.fullNames && errors.fullNames)}
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              {/* <TextField
                fullWidth
                label="Date of Birth"
                name="dobDate"
                type="date"
                onChange={handleChange}
                required
                value={values.dobDate}
                variant="outlined"
                InputLabelProps={{
                  shrink: true,
                }}
              /> */}
              <MuiPickersUtilsProvider utils={DateFnsUtils}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="Date of Birth"
                  format="dd-MMM-yyyy"
                  value={values.dob}
                  InputAdornmentProps={{ position: "end" }}
                  onChange={handleDOB}
                  KeyboardButtonProps={{
                    'aria-label':'Date of birth'
                  }}
                  required
                />
              </MuiPickersUtilsProvider>

            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="Village"
                name="village"
                onChange={handleChange}
                value={values.village}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="Phone Number"
                name="phoneNumber"
                onChange={handleChange}
                type="number"
                value={values.phoneNumber}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="Alternative Phone number"
                name="alternativePhoneNumber"
                onChange={handleChange}
                value={values.alternativePhoneNumber}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="HF Linked"
                name="hfLinked"
                onChange={handleChange}
                required
                select
                SelectProps={{ native: true }}
                value={values.hfLinked}
                variant="outlined"
              >
                {states.map((option) => (
                  <option
                    key={option.value}
                    value={option.value}
                  >
                    {option.label}
                  </option>
                ))}
              </TextField>
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="Other HF attended"
                name="otherHFAttended"
                onChange={handleChange}
                value={values.otherHFAttended}
                variant="outlined"
              />
            </Grid>
          </Grid>
        </CardContent>
        <Divider />
        <Box
          sx={{
            display: 'flex',
            justifyContent: 'flex-end',
            p: 2
          }}
        >
          <Button
            color="primary"
            variant="contained"
            onClick={() => resetClientDetails()}
            style={{marginRight: 5}}
          >
            Reset
          </Button>

          <Button
            color="primary"
            type="submit"
            variant="contained"
            //onClick={() => handleSave()}
            // onClick={() => e.preventDefault()}
          >
            Save details
          </Button>
        </Box>
      </Card>
    </form>
  );
};

export default ClientDetails;
