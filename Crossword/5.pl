 use Test::MockObject;
  my $mock = Test::MockObject->new();
    $mock->mock( 'fluorinate',
        sub { 'impurifying precious bodily fluids' } );
    print $mock->fluorinate;