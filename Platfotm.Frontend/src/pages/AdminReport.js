import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { adminReport, reset } from "../features/students/studentsSlice";

const AdminReport = () => {
  const dispatch = useDispatch();

  const { user } = useSelector((state) => state.reducer.auth);
  const { report } = useSelector((state) => state.students);

  useEffect(() => {
    dispatch(adminReport(user?.data?.token));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  console.log(report);
  return (
    <div>
      <h1>Admin Report</h1>
      <div style={{ margin: "30px 0 30px 0" }}>
        <h2>Overall Success Rate: {report?.data?.overallSuccessRate} %</h2>
      </div>
      <div>
        <h2>Selections Success Rate</h2>
        <div>
          {report?.data?.selectionSuccessesRate.map((sel) => {
            return (
              <h3 key={sel.id}>
                {sel.selectionTitle} : {sel.successRate} %
              </h3>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default AdminReport;
