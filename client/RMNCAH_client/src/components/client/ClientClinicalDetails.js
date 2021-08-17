import { useState, useEffect } from 'react';
import {
  Box,
  Button,
  Card,
  CardContent,
  CardHeader,
  Divider,
  Grid,
  TextField,
  MenuItem
} from '@material-ui/core';
import DateFnsUtils from '@date-io/date-fns';
import {
  MuiPickersUtilsProvider,
  KeyboardDatePicker
} from '@material-ui/pickers';
import { useSelector, useDispatch } from 'react-redux';
import * as Yup from 'yup';
import { useFormik } from 'formik';
import axios from 'axios';
import { NotificationManager } from 'react-notifications';
import { v4 as uuidv4 } from 'uuid';
import * as ACTION_TYPES from '../../actions/actions';

const deliveryOptions = [
  {
    value: 0,
    label: 'Select'
  },
  {
    value: 1,
    label: 'SBA'
  },
  {
    value: 2,
    label: 'HD (home delivery)'
  },
  {
    value: 3,
    label: 'BBA(Born before arrival)'
  }
];

const remarksOptions = [
  {
    value: 0,
    label: 'Select'
  },
  {
    value: 1,
    label: 'Abortion'
  },
  {
    value: 2,
    label: 'Miscarried'
  },
  {
    value: 3,
    label: 'Still birth'
  },
  {
    value: 4,
    label: 'Child death'
  }
];

const ClientClinicalDetails = (props) => {
  const dispatch = useDispatch();

  const fullNames = useSelector(
    (state) => state.main_reducer.clientDetails.fullNames
  );
  const dob = useSelector((state) => state.main_reducer.clientDetails.dob);
  const clientId = useSelector(
    (state) => state.main_reducer.clientDetails.clientId
  );
  const hfLinked = useSelector(
    (state) => state.main_reducer.clientDetails.hfLinked.facilityName
  );

  const clientClinicalDetailsFetched = useSelector(
    (state) => state.main_reducer.clientClinicalDetails
  );

  const calculate_age = () => {
    var today = new Date();
    var birthDate = new Date(dob); // create a date object directly from `dob1` argument
    var age_now = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age_now--;
    }
    return age_now;
  };

  const handleSave = (clientClinicalDetails) => {
    if (clientClinicalDetails.clientClinicalDetailsId === '') {
      clientClinicalDetails.clientClinicalDetailsId = uuidv4();
      console.log(clientClinicalDetails);
      axios
        .post('/api/client/addClientClinicalDetails', clientClinicalDetails)
        .then((response) => {
          NotificationManager.success('Saved Successfully!', '', 2000);
          formik.resetForm();
          dispatch({
            type: ACTION_TYPES.UPDATE_COMPONENT
          });
        })
        .catch((error) => {
          console.log(`error : ${error}`);
          NotificationManager.error('Error Save!', '', 10000);
        });
    } else {
      console.log(clientClinicalDetails);
      axios
        .post('/api/client/UpdateClientClinicalDetails', clientClinicalDetails)
        .then((response) => {
          NotificationManager.success('Updated Successfully!', '', 2000);
          dispatch({
            type: ACTION_TYPES.UPDATE_COMPONENT
          });
        })
        .catch((error) => {
          console.log(`error : ${error}`);
          NotificationManager.error('Error Update!', '', 10000);
        });
    }

    // axios
    //   .get('/api/client/clientdetails')
    //   .then((response) => {
    //     dispatch({
    //       type: ACTION_TYPES.CLIENT_LIST,
    //       payload: response.data
    //     });
    //   })
    //   .catch((error) => {
    //     console.log(`error : ${error}`);
    //   });
  };

  useEffect(() => {
    if (clientId === clientClinicalDetailsFetched.clientId) {
      formik.setValues(clientClinicalDetailsFetched);
    }
  }, [clientClinicalDetailsFetched]);

  const SignupSchema = Yup.object().shape({
    //fullNames: Yup.string().required(),
    //dob: Yup.date().required('Required')
  });

  const formik = useFormik({
    initialValues: {
      clientClinicalDetailsId: '',
      clientId: clientId,
      babyName: '',
      anc1: null,
      anc2: null,
      anc3: null,
      anc4: null,
      anc5: null,
      edd: null,
      delivery: '',
      penta1: null,
      penta2: null,
      penta3: null,
      mr1: null,
      remarks: ''
    },
    onSubmit: (values) => {
      handleSave(values);
    },
    validationSchema: SignupSchema,
    enableReinitialize: true
  });

  return (
    <form onSubmit={formik.handleSubmit}>
      <Card>
        <CardHeader
          // subheader="Enter client clinical details"
          title="Client Clinical Details"
        />
        <Divider />

        <CardContent>
          <Grid container spacing={3} marginBottom={3}>
            <Grid item md={3} xs={12}>
              <TextField
                fullWidth
                label="Full names"
                name="fullNames"
                value={fullNames}
                variant="outlined"
                inputProps={{
                  readOnly: true
                }}
              />
            </Grid>
            <Grid item md={3} xs={12}>
              <TextField
                fullWidth
                label="Age"
                name="age"
                value={calculate_age()}
                variant="outlined"
                inputProps={{
                  readOnly: true
                }}
              />
            </Grid>
            <Grid item md={3} xs={12}>
              <TextField
                fullWidth
                label="HF Linked"
                name="hfLinked"
                value={hfLinked}
                variant="outlined"
                inputProps={{
                  readOnly: true
                }}
              />
            </Grid>

            <Grid item md={3} xs={12}>
              <TextField
                fullWidth
                label="Baby Name"
                name="babyName"
                value={formik.values.babyName}
                onChange={formik.handleChange}
                variant="outlined"
              />
            </Grid>
          </Grid>

          <Grid container spacing={3}>
            <MuiPickersUtilsProvider utils={DateFnsUtils}>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="ANC 1"
                  format="dd-MMM-yyyy"
                  value={formik.values.anc1}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('anc1', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="ANC 2"
                  format="dd-MMM-yyyy"
                  value={formik.values.anc2}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('anc2', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="ANC 3"
                  format="dd-MMM-yyyy"
                  value={formik.values.anc3}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('anc3', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="ANC 4"
                  format="dd-MMM-yyyy"
                  value={formik.values.anc4}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('anc4', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="ANC 5"
                  format="dd-MMM-yyyy"
                  value={formik.values.anc5}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('anc5', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="EDD"
                  format="dd-MMM-yyyy"
                  value={formik.values.edd}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('edd', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                {/* <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="SBA"
                  format="dd-MMM-yyyy"
                  value={formik.values.sba}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('sba', val);
                  }}
                /> */}

                <TextField
                  fullWidth
                  name="delivery"
                  select
                  label="Delivery"
                  value={formik.values.delivery}
                  onChange={formik.handleChange}
                >
                  {deliveryOptions.map((option) => (
                    <MenuItem key={option.value} value={option.value}>
                      {option.label}
                    </MenuItem>
                  ))}
                </TextField>
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="PENTA 1"
                  format="dd-MMM-yyyy"
                  value={formik.values.penta1}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('penta1', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="PENTA 2"
                  format="dd-MMM-yyyy"
                  value={formik.values.penta2}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('penta2', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="PENTA 3"
                  format="dd-MMM-yyyy"
                  value={formik.values.penta3}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('penta3', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="MR 1"
                  format="dd-MMM-yyyy"
                  value={formik.values.mr1}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('mr1', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                {/* <TextField
                  fullWidth
                  label="Remark"
                  name="remarks"
                  onChange={formik.handleChange}
                  value={formik.values.remarks}
                  variant="outlined"
                /> */}

                <TextField
                  fullWidth
                  name="remarks"
                  select
                  label="Remarks"
                  value={formik.values.remarks}
                  onChange={formik.handleChange}
                >
                  {remarksOptions.map((option) => (
                    <MenuItem key={option.value} value={option.value}>
                      {option.label}
                    </MenuItem>
                  ))}
                </TextField>
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
            onClick={() => formik.resetForm()}
            style={{ marginRight: 5 }}
          >
            Reset
          </Button>
          <Button color="primary" variant="contained" type="submit">
            Save details
          </Button>
        </Box>
      </Card>
    </form>
  );
};

export default ClientClinicalDetails;
