import React from 'react';
import ReactDOM from 'react-dom';

import faker from 'faker';

import ApprovalCard from './ApprovalCard';
import CommentDetail from './CommentDetail';

const App = () => {
  return (
    <div className="ui container comments">
      <ApprovalCard>
        <div>
          <h4>Warning!</h4>
          <p>Are you sure you want to do this?</p>
        </div>
      </ApprovalCard>

      <ApprovalCard>
        <CommentDetail
          imageUrl={faker.image.imageUrl()}
          author="Sam"
          timeAgo="Today at 4:45PM"
          comment="Nice blog post!"
        />
      </ApprovalCard>

      <ApprovalCard>
        <CommentDetail
          imageUrl={faker.image.cats()}
          author="Felipe"
          timeAgo="Today at 2:00AM"
          comment="You are awesome..."
        />
      </ApprovalCard>

      <ApprovalCard>
        <CommentDetail
          imageUrl={faker.image.people()}
          author="Andreia"
          timeAgo="Yesterday at 5:00"
          comment="I want to be like you!!!"
        />
      </ApprovalCard>
    </div>
  );
};

ReactDOM.render(<App />, document.getElementById('root'));
