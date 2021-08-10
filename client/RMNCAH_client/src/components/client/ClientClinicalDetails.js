import { useState } from 'react';
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
import DateFnsUtils from '@date-io/date-fns';
import { MuiPickersUtilsProvider, KeyboardDatePicker } from '@material-ui/pickers';
import { useSelector, useDispatch } from 'react-redux';

const ClientClinicalDetails = (props) => {
  const fullNames = useSelector(state => state.main_reducer.clientDetails.fullNames);
  const dob = useSelector(state => state.main_reducer.clientDetails.dob);

  const [ANC1, setANC1] = useState(null);
  const [ANC2, setANC2] = useState('');
  const [ANC3, setANC3] = useState('');
  const [ANC4, setANC4] = useState('');
  const [ANC5, setANC5] = useState('');
  const [EDD, setEDD] = useState('');
  const [SBA, setSBA] = useState('');
  const [PENTA1, setPENTA1] = useState('');
  const [PENTA2, setPENTA2] = useState('');
  const [PENTA3, setPENTA3] = useState('');
  const [MR1, setMR1] = useState('');
  const [remarks, setRemarks] = useState('');

  const calculate_age = () => {
    var today = new Date();
    var birthDate = new Date(dob);  // create a date object directly from `dob1` argument
    var age_now = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) 
    {
        age_now--;
    }
    return age_now;
  }


  // const handleChange = (event) => {
  //   setValues({
  //     ...values,
  //     [event.target.name]: event.target.value
  //   });
  // };

  return (
    <form
      autoComplete="off"
      noValidate
      {...props}
    >
      <Card>
        <CardHeader
          // subheader="Enter client clinical details"
          title="Client Clinical Details"
        />
        <Grid
            container
            spacing={3}
            marginBottom={1}
            
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
                value={fullNames}
                variant="outlined"
                disabled
              />        
          </Grid>
          <Grid
            item
            md={4}
            xs={12}
          >          
            <TextField            
                fullWidth
                label="Age"
                name="age"
                value={calculate_age()}
                variant="outlined"
                disabled
              />        
          </Grid>
        </Grid>
        <Divider />
        <CardContent>
          <Grid
            container
            spacing={3}
          >
            <MuiPickersUtilsProvider utils={DateFnsUtils}>
              <Grid
                item
                md={4}
                xs={12}
              >          
                  <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="ANC 1"
                    format="dd-MMM-yyyy"
                    value={ANC1}
                    InputAdornmentProps={{ position: "end" }}
                    onChange={(e) => setANC1(e)}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
                
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="ANC 2"
                    format="dd-MMM-yyyy"
                    //value={values.dob}
                    InputAdornmentProps={{ position: "end" }}
                    //onChange={handleDOB}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="ANC 3"
                    format="dd-MMM-yyyy"
                    //value={values.dob}
                    InputAdornmentProps={{ position: "end" }}
                    //onChange={handleDOB}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="ANC 4"
                    format="dd-MMM-yyyy"
                    //value={values.dob}
                    InputAdornmentProps={{ position: "end" }}
                    //onChange={handleDOB}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="ANC 5"
                    format="dd-MMM-yyyy"
                    //value={values.dob}
                    InputAdornmentProps={{ position: "end" }}
                    //onChange={handleDOB}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="EDD"
                    format="dd-MMM-yyyy"
                    //value={values.dob}
                    InputAdornmentProps={{ position: "end" }}
                    //onChange={handleDOB}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="SBA"
                    format="dd-MMM-yyyy"
                    //value={values.dob}
                    InputAdornmentProps={{ position: "end" }}
                    //onChange={handleDOB}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="PENTA 1"
                    format="dd-MMM-yyyy"
                    //value={values.dob}
                    InputAdornmentProps={{ position: "end" }}
                    //onChange={handleDOB}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="PENTA 2"
                    format="dd-MMM-yyyy"
                    //value={values.dob}
                    InputAdornmentProps={{ position: "end" }}
                    //onChange={handleDOB}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="PENTA 3"
                    format="dd-MMM-yyyy"
                    //value={values.dob}
                    InputAdornmentProps={{ position: "end" }}
                    //onChange={handleDOB}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <KeyboardDatePicker
                    fullWidth
                    autoOk
                    disableFuture={true}
                    variant="inline"
                    inputVariant="outlined"
                    label="MR 1"
                    format="dd-MMM-yyyy"
                    //value={values.dob}
                    InputAdornmentProps={{ position: "end" }}
                    //onChange={handleDOB}
                    KeyboardButtonProps={{
                      'aria-label':'Date of birth'
                    }}
                    required
                  />
              </Grid>
              <Grid
                item
                md={4}
                xs={12}
              >
                <TextField
                  fullWidth
                  label="Remark"
                  name="remark"
                  //onChange={handleChange}
                  //value={values.remark}
                  variant="outlined"
                />
              </Grid>
            </MuiPickersUtilsProvider>
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
          >
            Save details
          </Button>
        </Box>
      </Card>
    </form>
  );
};

export default ClientClinicalDetails;
