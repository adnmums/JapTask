import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
  programs: null,
  isError: false,
  isSuccess: false,
  message: "",
};

export const getPrograms = createAsyncThunk(
  "programs/get",
  async (token, thunkAPI) => {
    try {
      const response = await axios.get("/api/programs", {
        headers: {
          Authorization: `bearer ${token}`,
        },
      });
      return response.data;
    } catch (error) {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();
      return thunkAPI.rejectWithValue(message);
    }
  }
);

export const programsSlice = createSlice({
  name: "programs",
  initialState,
  reducers: {
    reset: (state) => {
      state.isError = false;
      state.isSuccess = false;
      state.message = "";
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getPrograms.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(getPrograms.fulfilled, (state, action) => {
        state.programs = action.payload;
      });
  },
});

export const { reset } = programsSlice.actions;
export default programsSlice.reducer;
