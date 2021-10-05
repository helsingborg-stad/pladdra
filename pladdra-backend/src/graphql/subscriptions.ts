/* tslint:disable */
/* eslint-disable */
// this is an auto generated file. This will be overwritten

export const onCreateWorkspace = /* GraphQL */ `
  subscription OnCreateWorkspace($owner: String, $usersCanAccess: String) {
    onCreateWorkspace(owner: $owner, usersCanAccess: $usersCanAccess) {
      id
      name
      createdAt
      updatedAt
      description
      dialougeID
      usersCanWrite
      usersCanAccess
      groupsCanWrite
      groupsCanAccess
      blocks {
        items {
          id
          createdAt
          updatedAt
          workspaceID
          assetID
          owner
        }
        nextToken
      }
      owner
    }
  }
`;
export const onUpdateWorkspace = /* GraphQL */ `
  subscription OnUpdateWorkspace($owner: String, $usersCanAccess: String) {
    onUpdateWorkspace(owner: $owner, usersCanAccess: $usersCanAccess) {
      id
      name
      createdAt
      updatedAt
      description
      dialougeID
      usersCanWrite
      usersCanAccess
      groupsCanWrite
      groupsCanAccess
      blocks {
        items {
          id
          createdAt
          updatedAt
          workspaceID
          assetID
          owner
        }
        nextToken
      }
      owner
    }
  }
`;
export const onDeleteWorkspace = /* GraphQL */ `
  subscription OnDeleteWorkspace($owner: String, $usersCanAccess: String) {
    onDeleteWorkspace(owner: $owner, usersCanAccess: $usersCanAccess) {
      id
      name
      createdAt
      updatedAt
      description
      dialougeID
      usersCanWrite
      usersCanAccess
      groupsCanWrite
      groupsCanAccess
      blocks {
        items {
          id
          createdAt
          updatedAt
          workspaceID
          assetID
          owner
        }
        nextToken
      }
      owner
    }
  }
`;
export const onCreateAsset = /* GraphQL */ `
  subscription OnCreateAsset {
    onCreateAsset {
      id
      name
      type
      fileFormat
      fileName
      fileSize
      file {
        bucket
        key
        region
      }
      description
      createdAt
      updatedAt
    }
  }
`;
export const onUpdateAsset = /* GraphQL */ `
  subscription OnUpdateAsset {
    onUpdateAsset {
      id
      name
      type
      fileFormat
      fileName
      fileSize
      file {
        bucket
        key
        region
      }
      description
      createdAt
      updatedAt
    }
  }
`;
export const onDeleteAsset = /* GraphQL */ `
  subscription OnDeleteAsset {
    onDeleteAsset {
      id
      name
      type
      fileFormat
      fileName
      fileSize
      file {
        bucket
        key
        region
      }
      description
      createdAt
      updatedAt
    }
  }
`;
export const onCreateBlock = /* GraphQL */ `
  subscription OnCreateBlock($owner: String) {
    onCreateBlock(owner: $owner) {
      id
      createdAt
      updatedAt
      workspaceID
      assetID
      position {
        x
        y
        z
      }
      rotation {
        x
        y
        z
        w
      }
      owner
    }
  }
`;
export const onUpdateBlock = /* GraphQL */ `
  subscription OnUpdateBlock($owner: String) {
    onUpdateBlock(owner: $owner) {
      id
      createdAt
      updatedAt
      workspaceID
      assetID
      position {
        x
        y
        z
      }
      rotation {
        x
        y
        z
        w
      }
      owner
    }
  }
`;
export const onDeleteBlock = /* GraphQL */ `
  subscription OnDeleteBlock($owner: String) {
    onDeleteBlock(owner: $owner) {
      id
      createdAt
      updatedAt
      workspaceID
      assetID
      position {
        x
        y
        z
      }
      rotation {
        x
        y
        z
        w
      }
      owner
    }
  }
`;
export const onCreateDialogue = /* GraphQL */ `
  subscription OnCreateDialogue($owner: String, $usersCanAccess: String) {
    onCreateDialogue(owner: $owner, usersCanAccess: $usersCanAccess) {
      id
      name
      description
      status
      plannerArgs {
        workspace {
          initialScale
          minScale
          maxScale
          pinchToScale
        }
        block {
          collision
        }
        inventory {
          categories
          limitBy
          limitValue
        }
      }
      usersCanWrite
      usersCanAccess
      groupsCanWrite
      groupsCanAccess
      createdAt
      updatedAt
      owner
    }
  }
`;
export const onUpdateDialogue = /* GraphQL */ `
  subscription OnUpdateDialogue($owner: String, $usersCanAccess: String) {
    onUpdateDialogue(owner: $owner, usersCanAccess: $usersCanAccess) {
      id
      name
      description
      status
      plannerArgs {
        workspace {
          initialScale
          minScale
          maxScale
          pinchToScale
        }
        block {
          collision
        }
        inventory {
          categories
          limitBy
          limitValue
        }
      }
      usersCanWrite
      usersCanAccess
      groupsCanWrite
      groupsCanAccess
      createdAt
      updatedAt
      owner
    }
  }
`;
export const onDeleteDialogue = /* GraphQL */ `
  subscription OnDeleteDialogue($owner: String, $usersCanAccess: String) {
    onDeleteDialogue(owner: $owner, usersCanAccess: $usersCanAccess) {
      id
      name
      description
      status
      plannerArgs {
        workspace {
          initialScale
          minScale
          maxScale
          pinchToScale
        }
        block {
          collision
        }
        inventory {
          categories
          limitBy
          limitValue
        }
      }
      usersCanWrite
      usersCanAccess
      groupsCanWrite
      groupsCanAccess
      createdAt
      updatedAt
      owner
    }
  }
`;
export const onCreateInventory = /* GraphQL */ `
  subscription OnCreateInventory($owner: String) {
    onCreateInventory(owner: $owner) {
      id
      name
      dialougeID
      order
      createdAt
      updatedAt
      owner
    }
  }
`;
export const onUpdateInventory = /* GraphQL */ `
  subscription OnUpdateInventory($owner: String) {
    onUpdateInventory(owner: $owner) {
      id
      name
      dialougeID
      order
      createdAt
      updatedAt
      owner
    }
  }
`;
export const onDeleteInventory = /* GraphQL */ `
  subscription OnDeleteInventory($owner: String) {
    onDeleteInventory(owner: $owner) {
      id
      name
      dialougeID
      order
      createdAt
      updatedAt
      owner
    }
  }
`;
